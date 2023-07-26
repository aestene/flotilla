import { Chip, Table, Typography } from '@equinor/eds-core-react'
import { Mission } from 'models/Mission'
import styled from 'styled-components'
import { TaskStatusDisplay } from './TaskStatusDisplay'
import { useLanguageContext, TranslateTextUnsafe } from 'components/Contexts/LanguageContext'
import { Task, TaskStatus } from 'models/Task'
import { tokens } from '@equinor/eds-tokens'
import { GetColorsFromTaskStatus } from '../../../../utils/MarkerStyles'

const StyledTable = styled(Table)`
    grid-column: 1/ -1;
    font: equinor;
`

interface MissionProps {
    mission?: Mission
}

export function TaskTable({ mission }: MissionProps) {
    const { TranslateText } = useLanguageContext()
    var rows = mission && mission.tasks.length > 0 ? renderTasks(mission.tasks) : <></>
    return (
        <StyledTable>
            <Table.Caption>
                <Typography variant="h2">{TranslateText('Tasks')}</Typography>
            </Table.Caption>
            <Table.Head>
                <Table.Row>
                    <Table.Cell>#</Table.Cell>
                    <Table.Cell>{TranslateText('Tag-ID')}</Table.Cell>
                    <Table.Cell>{TranslateText('Description')}</Table.Cell>
                    <Table.Cell>{TranslateText('Inspection Types')}</Table.Cell>
                    <Table.Cell>{TranslateText('Status')}</Table.Cell>
                </Table.Row>
            </Table.Head>
            <Table.Body>{rows}</Table.Body>
        </StyledTable>
    )
}

function renderTasks(tasks: Task[]) {
    var rows = tasks?.map(function (task) {
        // Workaround for current bug in echo
        var order: number = task.taskOrder < 214748364 ? task.taskOrder + 1 : 1
        const rowStyle =
            task.status === TaskStatus.InProgress || task.status === TaskStatus.Paused
                ? { background: tokens.colors.infographic.primary__mist_blue.hex }
                : {}
        const markerColors = GetColorsFromTaskStatus(task.status)
        return (
            <Table.Row key={order} style={rowStyle}>
                <Table.Cell>
                    <Chip style={{ background: markerColors.fillColor }}>
                        <Typography variant="body_short_bold" style={{ color: markerColors.textColor }}>
                            {order}
                        </Typography>
                    </Chip>
                </Table.Cell>
                <Table.Cell> {renderTagId(task)}</Table.Cell>
                <Table.Cell> {renderDescription(task)}</Table.Cell>
                <Table.Cell> {renderInspectionTypes(task)} </Table.Cell>
                <Table.Cell>
                    <TaskStatusDisplay status={task.status} />
                </Table.Cell>
            </Table.Row>
        )
    })
    return rows
}

function renderTagId(task: Task) {
    if (!task.tagId) return <Typography>{'N/A'}</Typography>

    if (task.echoTagLink)
        return (
            <Typography link href={task.echoTagLink} target="_blank">
                {task.tagId!}
            </Typography>
        )
    else return <Typography>{task.tagId!}</Typography>
}

function renderDescription(task: Task) {
    if (!task.description) return <Typography>{'N/A'}</Typography>
    return <Typography>{task.description}</Typography>
}

function renderInspectionTypes(task: Task) {
    return task.inspections?.map(function (inspection) {
        if (inspection.inspectionUrl)
            return (
                <Typography link href={inspection.inspectionUrl}>
                    {TranslateTextUnsafe(inspection.inspectionType as string)}
                </Typography>
            )
        else return <Typography>{TranslateTextUnsafe(inspection.inspectionType as string)}</Typography>
    })
}
